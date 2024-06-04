import React from "react";
import "../styling/loginpage.css";
import { useNavigate } from "react-router-dom";
import { Outlet } from "react-router-dom";

function DoctorAccountPage() {
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
              onClick={() => toggleLoadPage("see-my-patients")}
            >
              See My Patients
            </button>
            <button
              className="buttonSign"
              onClick={() => toggleLoadPage("see-appointments")}
            >
              See My Appointments
            </button>
          </>
        </div>
      </div>
      <Outlet />
    </>
  );
}

export default DoctorAccountPage;