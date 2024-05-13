import React from "react";
import '../styling/homepage.css';

import InteractiveImage from "../components/InteractiveImage";


function Home() {
    return (
        <div className="background-container">
            <InteractiveImage
                imageName='anca' 
                imagePosition={{ left: '400px', top: '300px' }} 
                textPosition={{ left: '580px', top: '-300px' }}
                overlayText="Patient" 
                link='patient-login'
            />
            <InteractiveImage
                imageName='anca' 
                imagePosition={{ left: '500px', top: '300px' }} 
                textPosition={{ left: '280px', top: '-300px' }}
                overlayText="Doctor" 
                link='/patient-login'
            />
            <InteractiveImage
                imageName='anca' 
                imagePosition={{ left: '600px', top: '300px' }} 
                textPosition={{ left: '60', top: '-300px' }}
                overlayText="Admin" 
                link='/patient-login'
            />
            <InteractiveImage
                imageName='anca' 
                imagePosition={{ left: '700px', top: '300px' }} 
                textPosition={{ left: '-310px', top: '-300px' }}
                overlayText="Shop" // Specify the text to display on hover
                link='/patient-login'
            />
            
        </div>
        
      );

}
export default Home;
