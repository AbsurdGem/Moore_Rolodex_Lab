/* 
 * Author: Morgan Moore
 * Date: 12/07/2025
 * File: DatabaseHelper.cs
 * Purpose: Handles SQLite database interactions (CRUD) for Rolodex contacts.
 */

using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace MooreRolodexLab
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(string databaseFilePath = "rolodex.db")
        {
            _connectionString = $"Data Source={databaseFilePath};Version=3;";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string sql = @"
                CREATE TABLE IF NOT EXISTS Contacts (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    FirstName TEXT,
                    LastName TEXT,
                    PhoneNumber TEXT,
                    Email TEXT,
                    ContactType TEXT,
                    CompanyName TEXT,
                    JobTitle TEXT,
                    Relationship TEXT,
                    Nickname TEXT
                );";

            new SQLiteCommand(sql, connection).ExecuteNonQuery();
        }

        // ✅ CREATE
        public void InsertContact(Contact contact)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            string sql = @"
                INSERT INTO Contacts
                (FirstName, LastName, PhoneNumber, Email, ContactType,
                 CompanyName, JobTitle, Relationship, Nickname)
                VALUES
                (@First, @Last, @Phone, @Email, @Type,
                 @Company, @Title, @Relation, @Nick)";

            using var cmd = new SQLiteCommand(sql, conn);

            cmd.Parameters.AddWithValue("@First", contact.FirstName);
            cmd.Parameters.AddWithValue("@Last", contact.LastName);
            cmd.Parameters.AddWithValue("@Phone", contact.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", contact.Email);
            cmd.Parameters.AddWithValue("@Type", contact.GetType().Name);

            string company = null, title = null, relation = null, nick = null;

            if (contact is BusinessContact b)
            {
                company = b.CompanyName;
                title = b.JobTitle;
            }
            else if (contact is FamilyContact f)
            {
                relation = f.Relationship;
            }
            else if (contact is FriendContact fr)
            {
                nick = fr.Nickname;
            }

            cmd.Parameters.AddWithValue("@Company", (object?)company ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Title", (object?)title ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Relation", (object?)relation ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Nick", (object?)nick ?? DBNull.Value);

            cmd.ExecuteNonQuery();
        }

        // ✅ READ
        public List<Contact> GetAllContacts()
        {
            List<Contact> list = new();
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            string sql = "SELECT * FROM Contacts";
            using var cmd = new SQLiteCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(MapReaderToContact(reader));
            }

            return list;
        }

        // ✅ UPDATE
        public void UpdateContact(Contact contact)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            string sql = @"
                UPDATE Contacts SET
                FirstName=@First, LastName=@Last,
                PhoneNumber=@Phone, Email=@Email
                WHERE Id=@Id";

            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@First", contact.FirstName);
            cmd.Parameters.AddWithValue("@Last", contact.LastName);
            cmd.Parameters.AddWithValue("@Phone", contact.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", contact.Email);
            cmd.Parameters.AddWithValue("@Id", contact.Id);

            cmd.ExecuteNonQuery();
        }

        // ✅ DELETE
        public void DeleteContact(int id)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            string sql = "DELETE FROM Contacts WHERE Id=@Id";
            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }

        // ✅ POLYMORPHIC MAPPER (FIXED)
        private Contact MapReaderToContact(SQLiteDataReader r)
        {
            int id = Convert.ToInt32(r["Id"]);
            string first = r["FirstName"].ToString();
            string last = r["LastName"].ToString();
            string phone = r["PhoneNumber"].ToString();
            string email = r["Email"].ToString();
            string type = r["ContactType"].ToString();

            string company = r["CompanyName"]?.ToString();
            string title = r["JobTitle"]?.ToString();
            string relation = r["Relationship"]?.ToString();
            string nick = r["Nickname"]?.ToString();

            Address addr = new Address("Unknown", "Unknown", "XX", "00000");

            return type switch
            {
                nameof(BusinessContact) => new BusinessContact(id, first, last, phone, email, addr, company ?? "", title ?? ""),
                nameof(FamilyContact) => new FamilyContact(id, first, last, phone, email, addr, relation ?? ""),
                nameof(FriendContact) => new FriendContact(id, first, last, phone, email, addr, nick ?? ""),
                _ => new FriendContact(id, first, last, phone, email, addr, "")
            };
        }
    }
}
