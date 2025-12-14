/*
 * Author: Morgan Moore
 * Date: 12/07/2025
 * Assignment: Week 4 – Database Interactions
 * File: DatabaseHelper.cs
 * Purpose:
 * Handles all SQLite database operations (Create, Read, Update, Delete)
 * for Rolodex contacts. Demonstrates abstraction, polymorphism, and
 * database interaction using SQLite.
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

        // ✅ CREATE TABLE
        private void InitializeDatabase()
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string sql = @"
                CREATE TABLE IF NOT EXISTS Contacts (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    FirstName TEXT NOT NULL,
                    LastName TEXT NOT NULL,
                    PhoneNumber TEXT,
                    Email TEXT,
                    ContactType TEXT NOT NULL,
                    CompanyName TEXT,
                    JobTitle TEXT,
                    Relationship TEXT,
                    Nickname TEXT
                );
            ";

            using var command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        // ✅ CREATE
        public int InsertContact(Contact contact)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string sql = @"
                INSERT INTO Contacts
                (FirstName, LastName, PhoneNumber, Email, ContactType,
                 CompanyName, JobTitle, Relationship, Nickname)
                VALUES
                (@FirstName, @LastName, @PhoneNumber, @Email, @ContactType,
                 @CompanyName, @JobTitle, @Relationship, @Nickname);
                SELECT last_insert_rowid();
            ";

            using var command = new SQLiteCommand(sql, connection);
            FillCommonParameters(command, contact);

            return Convert.ToInt32(command.ExecuteScalar());
        }

        // ✅ READ ALL
        public List<Contact> GetAllContacts()
        {
            var results = new List<Contact>();

            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            using var command = new SQLiteCommand("SELECT * FROM Contacts;", connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                results.Add(MapReaderToContact(reader));
            }

            return results;
        }

        // ✅ UPDATE
        public void UpdateContact(Contact contact)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string sql = @"
                UPDATE Contacts
                SET FirstName = @FirstName,
                    LastName = @LastName,
                    PhoneNumber = @PhoneNumber,
                    Email = @Email,
                    ContactType = @ContactType,
                    CompanyName = @CompanyName,
                    JobTitle = @JobTitle,
                    Relationship = @Relationship,
                    Nickname = @Nickname
                WHERE Id = @Id;
            ";

            using var command = new SQLiteCommand(sql, connection);
            FillCommonParameters(command, contact);
            command.Parameters.AddWithValue("@Id", contact.Id);

            command.ExecuteNonQuery();
        }

        // ✅ DELETE
        public void DeleteContact(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            using var command =
                new SQLiteCommand("DELETE FROM Contacts WHERE Id = @Id;", connection);

            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }

        // ✅ PARAMETER HELPER (POLYMORPHISM)
        private void FillCommonParameters(SQLiteCommand command, Contact contact)
        {
            command.Parameters.AddWithValue("@FirstName", contact.FirstName);
            command.Parameters.AddWithValue("@LastName", contact.LastName);
            command.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
            command.Parameters.AddWithValue("@Email", contact.Email);

            string type = contact.GetType().Name;

            string company = null;
            string job = null;
            string relationship = null;
            string nickname = null;

            if (contact is BusinessContact b)
            {
                company = b.CompanyName;
                job = b.JobTitle;
            }
            else if (contact is FamilyContact f)
            {
                relationship = f.Relationship;
            }
            else if (contact is FriendContact fr)
            {
                nickname = fr.Nickname;
            }

            command.Parameters.AddWithValue("@ContactType", type);
            command.Parameters.AddWithValue("@CompanyName", (object?)company ?? DBNull.Value);
            command.Parameters.AddWithValue("@JobTitle", (object?)job ?? DBNull.Value);
            command.Parameters.AddWithValue("@Relationship", (object?)relationship ?? DBNull.Value);
            command.Parameters.AddWithValue("@Nickname", (object?)nickname ?? DBNull.Value);
        }

        // ✅ MAP ROW → OBJECT
        private Contact MapReaderToContact(SQLiteDataReader reader)
        {
            int id = Convert.ToInt32(reader["Id"]);
            string first = reader["FirstName"]?.ToString() ?? "";
            string last = reader["LastName"]?.ToString() ?? "";
            string phone = reader["PhoneNumber"]?.ToString() ?? "";
            string email = reader["Email"]?.ToString() ?? "";
            string type = reader["ContactType"]?.ToString() ?? "";

            return type switch
            {
                nameof(BusinessContact) =>
                    new BusinessContact(
                        id,
                        first,
                        last,
                        phone,
                        email,
                        reader["CompanyName"]?.ToString() ?? "",
                        reader["JobTitle"]?.ToString() ?? ""
                    ),

                nameof(FamilyContact) =>
                    new FamilyContact(
                        id,
                        first,
                        last,
                        phone,
                        email,
                        reader["Relationship"]?.ToString() ?? ""
                    ),

                nameof(FriendContact) =>
                    new FriendContact(
                        id,
                        first,
                        last,
                        phone,
                        email,
                        reader["Nickname"]?.ToString() ?? ""
                    ),

                _ =>
                        new FriendContact(id, first, last, phone, email, "")
            };
        }
    }
}
