README

Project: SteelHorseTrucks Security Enhancement  
Team: Delta Team  
Date Range: April 9–11, 2025

---

2025-04-09

09:30:18 Victor – Loaded the SteelHorseTrucks project in Visual Studio 2022  
09:42:55 Victor – Fixed SendGrid API key issue and tested the email sender manually  
10:05:12 Victor – Decided to drop SendGrid integration and implement internal MFA  
10:22:33 Victor – Developed custom MFA system with code generation and email simulation  
10:45:47 Victor – Configured MFA to open code in a new tab for better UX  
11:10:25 Victor – Implemented redirection after successful MFA to `/Admin` for admin users  
11:25:19 Victor – Created the User Management interface accessible to administrators  
11:38:40 Victor – Built Razor views: Index, EditRoles, and Delete under `Views/UserManagement`  
11:49:51 Victor – Secured admin features using `[Authorize(Roles = "Admin")]`  
12:10:02 Victor – Updated navigation menu to include “Manage Users” and “Login Logs” for admin only  
12:22:41 Akhil – Reviewed custom MFA flow and suggested usability improvements  
12:35:08 Vishal – Tested role-based access control across restricted pages

---

2025-04-10

09:02:17 Victor – Updated TrucksController to restrict CRUD operations to Admin role  
09:10:44 Victor – Refactored Razor views for Trucks to include clearer labels:  
            • "Payload Capacity (ton)"  
            • "Warranty (year(s))"  
09:25:58 Victor – Modified the "Year" field to use a DateTime picker  
09:42:11 Victor – Adjusted "Price" field to display values in CAD format  
10:04:33 Victor – Applied Entity Framework migration and updated the database schema  
10:25:18 Victor – Implemented `LoginLog` entity to track all login attempts (status, IP, timestamp)  
10:35:12 Victor – Extended `Login.cshtml.cs` to write login events to the database  
10:52:22 Victor – Created method in `AdminController` to list login logs  
11:05:44 Victor – Developed `LoginLogs.cshtml` view with color-coded success/failure indicators  
11:20:29 Victor – Linked "Login Logs" page in admin navigation menu  
11:35:15 Victor – Ensured CRUD options are hidden for non-admin users  
11:45:51 Victor – Completed verification of admin-only access controls in Trucks and User Management  
12:00:17 Akhil – Assisted in improving frontend formatting and layout of the Login Logs table  
12:18:49 Vishal – Performed security review of database migration and confirmed data integrity

---

2025-04-11

08:20:11 Victor – Prepared Blue Team report structure in Word format  
08:34:59 Victor – Authored sections: Executive Summary, Methodology, Detection Effectiveness  
09:10:17 Victor – Documented MFA implementation, RBAC enforcement, and admin-only CRUD as mitigation strategies  
09:23:42 Victor – Wrote “Lessons Learned” and “Best Practices” sections, including insights on credential management  
09:40:06 Victor – Added content under “Threat Intelligence” recommending GitHub Dependabot and Azure integrations  
10:15:34 Victor – Updated “User Awareness” section with a real incident and proposed training action plan  
10:30:00 Victor – Captured and organized screenshots of MFA, User Management, Trucks CRUD, and Login Logs  
10:48:19 Akhil – Reviewed the Blue Team report and provided suggestions on layout and visual clarity  
11:10:35 Vishal – Verified alignment between application behavior and report claims; conducted final smoke tests

---

Group Members and Roles:

**Victor** – Lead developer, security hardening architect, and documentation coordinator  
**Akhil** – UI/UX contributor, frontend enhancements, report formatting support  
**Vishal** – Tester and reviewer, responsible for QA, validation, and configuration checks
