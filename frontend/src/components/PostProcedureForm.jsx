import React, { useState } from "react";
import "../styling/loginpage.css";
import "../styling/form.css";
import { useNavigate, Form, redirect } from "react-router-dom";
import axios from "axios";
import { SERVER_BASE_URL } from "../consts";

export default function PostProcedureForm() {
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
        method="POST"
        action="/admin-account/admin-see-procedure/post-procedure"
        className="form-container"
      >
        <h1>Post Procedure</h1>
        <div className="input-container">
          <label htmlFor="name"></label>
          <input
            placeholder="name"
            type="text"
            className="short-input"
            id="name"
            defaultValue={data["name"]}
            name="name"
            onChange={(e) => handleData(e, "name")}
          />
        </div>
        <button className="submit-btn">Post Procedure</button>
      </Form>
    </>
  );
}