import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import { RouterProvider } from "react-router-dom";
import ErrorPage from "./pages/ErrorPage";
import PatientLogin from "./pages/PatientLogin";
import { createBrowserRouter } from "react-router-dom";
import LoginPage from "./pages/LoginPage";
import SignUpPage from "./pages/SignUpPage";
import Root from "./Root";
import { action as signupAction } from "./components/SignUpForm";
import { action as loginAction } from "./components/LoginForm";
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
            // errorElement: <LoginPage />,
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
    ],
  },
]);

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
