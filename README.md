
🏥 Hospital Database and Appointment Manager

A full-stack web application built with ASP.NET WebAPI (backend) and React (frontend) for managing patients, appointments, hospital sections, and procedures.

This system provides healthcare facilities with an efficient, modern way to organize patient records, schedule appointments, and generate useful reports.

🚀 Features

👨‍⚕️ Patient Management

- Store and manage patient records (personal info & medical history)
- Easily update and retrieve health records

📅 Appointment Scheduling

- Patients can book, reschedule, or cancel appointments
- Automatic reminders for upcoming appointments
- Resource allocation to optimize doctor and facility usage

✅ Benefits

- Reduces paperwork & manual errors
- Improves patient experience with online scheduling
- Provides data insights for hospital administration

🛠 Tech Stack

- Backend – ASP.NET WebAPI (.NET 8.5)
- Entity Framework Core for database management
- JWT Authentication for security
- Swagger (Swashbuckle) for API testing & documentation

Key Controllers:

- AppointmentController – manages appointment system
- ProcedureController – manages hospital procedures
- SectionController – manages hospital sections
- UserController – manages users & roles
- Database – SQL Server

 🗄️ Database – SQL Server

-   Code-First approach with EF Core migrations
-   Managed through SQL Server Management Studio
    

 💻 Frontend – React

-   React Router for navigation    
-   Redux for state management 
-   Axios for API communication
-   Responsive UI with role-based dashboards:
    - Patient – manage appointments, view doctors, account settings
    -   Doctor – view assigned patients and appointments
    -   Admin – full CRUD on users, sections, procedures, and appointments

📂 Project Structure

/Hospital_Database

- Backend (ASP.NET WebAPI)
	- Controllers/
	- Data/
	- Models/
	- DTOs/
	- Program.cs

- Frontend (React)
	- components/
	- pages/
	- redux/
	- App.js
	- index.js

- README.md

⚙️ Installation

**Backend**:

Clone repository:

	git clone https://github.com/DenisK11/Hospital_Database.git
	cd Hospital_Database/backend
	
Install dependencies:

	dotnet restore
	
Run migrations & update DB:

	dotnet ef database update

Start the backend server:

	dotnet run
	
**Frontend**:

Navigate to frontend folder:

	cd Hospital_Database/frontend

Install dependencies:

	npm install

Start development server:
	
	npm start

🔒 Security

- JWT Authentication for role-based access control
- Role-based dashboards (Patient / Doctor / Admin)
- Only authorized users can access sensitive operations

📊 Testing & Quality Assurance

- Swagger used for API endpoint testing
- Requirement Module ensured coverage of all functional needs
- Final tests passed with all requirements met
	
🧑‍🤝‍🧑 Team

- Kuth Denis-Ioan – Team Leader / Developer
- Horea Haragis – Developer
- Rad Emilian Antonio – Developer
- Iles Ioan Rares – Tester / Developer

📜 License

This project is released under the MIT License.