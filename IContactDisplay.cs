/*
 * Author: Morgan Moore
 * Date: 12/07/2025
 * Assignment: Week 4 – Database Interactions
 * File: IContactDisplay.cs
 * Purpose:
 * Interface that defines display behavior for contacts.
 * Demonstrates the use of interfaces to enforce consistent
 * output formatting across different contact types.
 */

namespace MooreRolodexLab
{
    public interface IContactDisplay
    {
        string GetSummaryLine();
        string GetDetailText();
    }
}
