import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "../styling/homepage.css";

const InteractiveImage = ({
  imageName,
  imagePosition,
  textPosition,
  overlayText,
  link,
}) => {
  const [hovered, setHovered] = useState(false);
  const navigate = useNavigate();

  const handleMouseEnter = () => {
    setHovered(true);
  };

  const handleMouseLeave = () => {
    setHovered(false);
  };

  const handleClick = () => {
    navigate(link);
  };

  return (
    <div
      className="interactive-image-container"
      style={{ position: "relative", ...imagePosition }}
    >
      <img
        src={`../assets/${imageName}.png`}
        alt="Interactive Image"
        className={`interactive-image`}
        onMouseEnter={handleMouseEnter}
        onMouseLeave={handleMouseLeave}
        onClick={handleClick}
      />
      {hovered && (
        <div
          className="overlay"
          style={{ position: "absolute", ...textPosition }}
        >
          {overlayText}
        </div>
      )}
    </div>
  );
};

export default InteractiveImage;
