/* 
 * Author: Morgan Moore
 * Date: 11/30/2025
 * File: IContactDisplay.cs
 * Purpose: Interface defining display behavior for all contacts.
 */

namespace MooreRolodexLab
{
    public interface IContactDisplay
    {
        string GetSummaryLine();
        string GetDetailText();
    }
}
