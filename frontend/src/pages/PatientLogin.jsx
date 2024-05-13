import React from "react";
import "../styling/loginpage.css";
import { useNavigate } from "react-router-dom";
import { Outlet } from "react-router-dom";

function PatientLogin() {
  const navigate = useNavigate();

  const toggleLoadPage = (page) => {
    navigate(page);
  };

  return (
    <>
      <div className="login-container">
        <img src="../assets/anca.png" alt="Login Image" />
        <div className="purple-overlay">
          <>
            <button
              className="buttonLog"
              onClick={() => toggleLoadPage("login")}
            >
              Log In
            </button>
            <button
              className="buttonSign"
              onClick={() => toggleLoadPage("signup")}
            >
              Sign Up
            </button>
          </>
        </div>
      </div>
      <Outlet />
    </>
  );
}

export default PatientLogin;
