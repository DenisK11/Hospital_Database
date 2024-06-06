import React, { useState } from "react";
import "../styling/loginpage.css";
import "../styling/form.css";
import { useNavigate, Form, redirect } from "react-router-dom";
import axios from "axios";
import { SERVER_BASE_URL } from "../consts";

export default function DeleteAppointmentPatientForm() {
  const navigate = useNavigate();
  const [data, setData] = useState({
    id: ""
  });

  const handleData = (e, identifier) => {
    setData((prevData) => {
      let newData = prevData;
      newData[identifier] = e.target.value;
      return newData;
    });
  };

  return (
    <>
      <Form
        method="DELETE"
        action="/admin-account/admin-see-appointments/delete-appointment"
        className="form-container"
      >
        <h1>Delete Appointment</h1>
        <div className="input-container">
          <label htmlFor="id"></label>
          <input
            placeholder="id"
            type="number"
            className="short-input"
            id="id"
            defaultValue={data["id"]}
            name="id"
            onChange={(e) => handleData(e, "id")}
          />
        </div>
        <button className="submit-btn">Delete Appointment</button>
      </Form>
    </>
  );
}