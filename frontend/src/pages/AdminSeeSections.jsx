import React from "react";
import "../styling/loginpage.css";
import { useNavigate } from "react-router-dom";
import { Outlet } from "react-router-dom";

function AdminSeeSections() {
  const navigate = useNavigate();

  const toggleLoadPage = (page) => {
    navigate(page);
  };

  return (
    <>
      <div className="login-container">
        <div className="purple-overlay">
          <>
            <button
              className="buttonLog"
              onClick={() => toggleLoadPage("get-all-sections")}
            >
              Get All Sections
            </button>
            <button
              className="buttonSign"
              onClick={() => toggleLoadPage("delete-section")}
            >
               Delete Section
            </button>
            <button
              className="buttonSign"
              onClick={() => toggleLoadPage("post-section")}
            >
              Post Section
            </button>
          </>
        </div>
      </div>
      <Outlet />
    </>
  );
}

export default AdminSeeSections;