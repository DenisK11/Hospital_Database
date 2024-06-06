import React from "react";
import "../styling/loginpage.css";
import { useNavigate } from "react-router-dom";
import { Outlet } from "react-router-dom";

function PatientAccount() {
  const navigate = useNavigate();

  const toggleLoadPage = (page) => {
    navigate(page);
  };

  const handleDeleteAccount = () => {
    // Handle the account deletion logic here
    alert("Account deleted");
  };

  return (
    <>
     <button
          className="delete-account-button"
          onClick={handleDeleteAccount}
        >
          Delete Account
        </button>
        <button
          className="delete-appointment-button"
          onClick={() => toggleLoadPage("delete-appointment-patient")}
        >
          Delete Appointment
        </button>
      <div className="login-container">
        <img src="../assets/anca.png" alt="Login Image" />
        <div className="purple-overlay">
          <>
            <button
              className="buttonLog"
              onClick={() => toggleLoadPage("make-appointment")}
            >
              Make Appointment
            </button>
            <button
              className="buttonSign"
              onClick={() => toggleLoadPage("see-appointment")}
            >
              See Appointment
            </button>
            <button
              className="buttonSign"
              onClick={() => toggleLoadPage("see-doctors")}
            >
              See Doctors
            </button>
            <button
              className="buttonSign"
              onClick={() => toggleLoadPage("see-sections")}
            >
              See Sections
            </button>
          </>
        </div>
       
      </div>
      
      <Outlet />
    </>
  );
}

export default PatientAccount;
