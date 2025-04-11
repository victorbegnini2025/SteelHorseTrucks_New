README

2025-04-09

09:30:18 Victor - Loaded the SteelHorseTrucks project in Visual Studio 2022
09:42:55 Victor - Fixed SendGrid API key issue and tested email sender manually
10:05:12 Victor - Decided to drop SendGrid integration and build internal MFA
10:22:33 Victor - Implemented custom MFA system with code generation and email simulation
10:45:47 Victor - Configured MFA to open code in a new tab
11:10:25 Victor - Adjusted redirection after successful MFA to go to /Admin for admins
11:25:19 Victor - Created User Management interface for admin users
11:38:40 Victor - Built Razor views: Index, EditRoles, and Delete under Views/UserManagement
11:49:51 Victor - Restricted admin access using [Authorize(Roles = "Admin")]
12:10:02 Victor - Built navigation menu with "Manage Users" and "Login Logs" only for admins

2025-04-10

09:02:17 Victor - Applied changes to TrucksController to restrict CRUD actions to Admin
09:10:44 Victor - Updated Razor Views for Trucks (Create, Edit, Delete, Details) to align with improved labels: Payload Capacity (ton), Warranty (year(s))
09:25:58 Victor - Changed Year field type to DateTime and allowed calendar selection
09:42:11 Victor - Modified Price field to display in CAD currency
10:04:33 Victor - Added Entity Framework migration and updated database schema
10:25:18 Victor - Implemented LoginLog entity to store login attempts (success/failure, IP, timestamp)
10:35:12 Victor - Modified Login.cshtml.cs to log login attempts to database
10:52:22 Victor - Created AdminController method to view login logs
11:05:44 Victor - Created LoginLogs.cshtml to render login logs table with success/failure color-coded
11:20:29 Victor - Connected navigation link in _Layout.cshtml for Login Logs
11:35:15 Victor - Added logic to hide CRUD actions from non-admin users
11:45:51 Victor - Verified admin-only restriction works correctly in Trucks and UserManagement interfaces

2025-04-11

08:20:11 Victor - Prepared Blue Team report structure in Word format
08:34:59 Victor - Wrote sections: Executive Summary, Methodology, and Detection Effectiveness
09:10:17 Victor - Documented custom MFA implementation, user role enforcement, and admin-only CRUD as response strategies
09:23:42 Victor - Wrote lessons learned and best practices, highlighting hardcoded credentials and the need for training
09:40:06 Victor - Added paragraph under Threat Intelligence about possible Azure integrations and GitHub Dependabot
10:15:34 Victor - Rewrote User Awareness section to include real security incident and action plan for training
10:30:00 Victor - Captured screenshots from MFA, User Management, Trucks CRUD, and Login Logs for Blue Team report

Group Members:

Victor (main implementation and documentation lead)
Akhil (contributor on UI changes and logic verification)
Vishal (supported testing and configuration review)

These logs provide a detailed changelog of activities and implementations conducted during the project refactoring and security hardening by Delta Team