import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import { RouterProvider } from "react-router-dom";
import ErrorPage from "./pages/ErrorPage";
import PatientLogin from "./pages/PatientLogin";
import DoctorLogin from "./pages/DoctorLogin";
import AdminLogin from "./pages/AdminLogin";
import { createBrowserRouter } from "react-router-dom";
import LoginPage from "./pages/LoginPage";
import DoctorLoginPage from "./pages/DoctorLoginPage";
import AdminLoginPage from "./pages/AdminLoginPage";
import SignUpPage from "./pages/SignUpPage";
import Root from "./Root";
import { action as signupAction } from "./components/SignUpForm";
import { action as loginAction } from "./components/LoginForm";
import { action as doctorLoginAction } from "./components/LoginFormDoctor";
import { action as adminLoginAction } from "./components/LoginFormAdmin";
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
    ],
  },
]);

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
