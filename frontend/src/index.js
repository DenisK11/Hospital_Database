import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import { RouterProvider } from "react-router-dom";
import ErrorPage from "./pages/ErrorPage";
import PatientLogin from "./pages/PatientLogin";
import DoctorLogin from "./pages/DoctorLogin";
import AdminLogin from "./pages/AdminLogin";
import MakeAppointmentPage from "./pages/MakeAppointmentPage";
import SeeAppointmentPage from "./pages/SeeAppointmentPage";
import SeeDoctorsPage from "./pages/SeeDoctorsPage";
import SeeSectionsPage from "./pages/SeeSectionsPage";
import { createBrowserRouter } from "react-router-dom";
import LoginPage from "./pages/LoginPage";
import DoctorLoginPage from "./pages/DoctorLoginPage";
import SeemyPatients from "./pages/SeemyPatients";
import AdminLoginPage from "./pages/AdminLoginPage";
import DoctorAccountPage from "./pages/DoctorAccountPage";
import AdminAccountPage from "./pages/AdminAccountPage";
import AdminSeeAppointments from "./pages/AdminSeeAppointments";
import AdminSeeProcedures  from "./pages/AdminSeeProcedures";
import AdminSeeSections from "./pages/AdminSeeSections";
import AdminSeeUsers from "./pages/AdminSeeUsers";
import SeeDoctorAppointments from "./pages/SeeDoctorAppointments";
import SignUpPage from "./pages/SignUpPage";
import GetAllAppointments from "./pages/GetAllAppointments";
import DeleteAppointment from "./pages/DeleteAppointment";
import AdminMakeAppointment from "./pages/AdminMakeAppointment"
import PostSection from "./pages/PostSection";
import DeleteSection from "./pages/DeleteSection";
import GetAllSections from "./pages/GetAllSections";
import GetAllProcedures from "./pages/GetAllProcedures";
import DeleteProcedure from "./pages/DeleteProcedure";
import PostProcedure from "./pages/PostProcedure";
import DeleteAppointmentPatient from "./pages/DeleteAppointmentPatient";

import Root from "./Root";
import { action as signupAction } from "./components/SignUpForm";
import { action as loginAction } from "./components/LoginForm";
import { action as doctorLoginAction } from "./components/LoginFormDoctor";
import { action as adminLoginAction } from "./components/LoginFormAdmin";
import {action  as makeAppointmentAction} from "./components/MakeAppointmentForm";
import PatientAccount from "./pages/PatientAccount";

const router = createBrowserRouter([
  {
    errorElement: <ErrorPage />,
    children: [
      {
        index: true,
        element: <Root />,
      },
      {
        path: "patient-login",
        children: [
          {
            index: true,
            element: <PatientLogin />,
          },
          {
            path: "signup",
            element: <SignUpPage />,
            action: signupAction,
          },
          {
            path: "login",
            element: <LoginPage />,
            action: loginAction,
          },
        ],
      },
      {
        path: "patient-account",
        children: [
          {
            index: true,
            element: <PatientAccount />,
          },
          {
            path: "make-appointment",
            element: <MakeAppointmentPage />,
            action: makeAppointmentAction,
          },
          {
            path: "see-appointment",
            element: <SeeAppointmentPage />,
          },
          {
            path: "see-sections",
            element: <SeeSectionsPage />,
          },
          {
            path: "see-doctors",
            element: <SeeDoctorsPage />,
          },
          {
            path: "delete-appointment-patient",
            element: <DeleteAppointmentPatient />
          }
        ],
      },
      {
        path: "doctor-login",
        children: [
          {
            index: true,
            element: <DoctorLogin />,
          },
          {
            path: "login",
            element: <DoctorLoginPage />,
            action: doctorLoginAction,
          },
        ],
      },
      {
        path: "doctor-account",
        children: [
          {
            index: true,
            element: <DoctorAccountPage />,
          },
          {
            path: "see-appointments",
            element: <SeeDoctorAppointments />,
          },
          {
            path: "see-my-patients",
            element: <SeemyPatients />,
          },
        ],
      },
      {
        path: "admin-login",
        children: [
          {
            index: true,
            element: <AdminLogin />,
          },
          {
            path: "login",
            element: <AdminLoginPage />,
            action: adminLoginAction,
          },
        ],
      },
      {
        path: "admin-account",
        children: [
          {
            index: true,
            element: <AdminAccountPage />,
          },
          {
            path: "admin-see-appointments",
            element: <AdminSeeAppointments />,
          },
          {
            path: "admin-see-procedures",
            element: <AdminSeeProcedures />,
          }, 
          {
            path: "admin-see-sections",
            element: <AdminSeeSections />,
          }, 
          {
            path: "admin-see-users",
            element: <AdminSeeUsers />,
          },
          {
            path: "get-all-appointments",
            element: <GetAllAppointments />,
          },
        ],
      },
      {
        path: "admin-account/admin-see-appointments",
        children: [
          {
            index: true,
            element: <AdminSeeAppointments />,
          },
          {
            path: "get-all-appointments",
            element: <GetAllAppointments />,
          },
          {
            path: "delete-appointment",
            element: <DeleteAppointment />,
          },
          {
            path: "admin-make-appointment",
            element: <AdminMakeAppointment />,
          },
        ],
      },
      {
        path: "admin-account/admin-see-sections",
        children: [
          {
            index: true,
            element: <AdminSeeSections />,
          },
          {
            path: "get-all-sections",
            element: <GetAllSections />,
          },
          {
            path: "delete-section",
            element: <DeleteSection />,
          },
          {
            path: "post-section",
            element: <PostSection />,
          },
        ],
      },
      {
        path: "admin-account/admin-see-procedures",
        children: [
          {
            index: true,
            element: <AdminSeeProcedures />,
          },
          {
            path: "get-all-procedures",
            element: <GetAllProcedures />,
          },
          {
            path: "delete-procedure",
            element: <DeleteProcedure />,
          },
          {
            path: "post-procedure",
            element: <PostProcedure />,
          },
        ],
      },
      {
        path: "admin-account/admin-see-users",
        children: [
          {
            index: true,
            element: <AdminSeeUsers />,
          },
        ]
      },
    ],
  },
]);

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
