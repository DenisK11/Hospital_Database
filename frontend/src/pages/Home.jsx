import React from "react";
import '../styling/homepage.css';

import InteractiveImage from "../components/InteractiveImage";


function Home() {
    return (
        <div className="background-container">
            <InteractiveImage
                imageName='anca' 
                imagePosition={{ left: '550px', top: '300px' }} 
                textPosition={{ left: '480px', top: '-300px' }}
                overlayText="Patient" 
                link='patient-login'
            />
            <InteractiveImage
                imageName='anca' 
                imagePosition={{ left: '650px', top: '300px' }} 
                textPosition={{ left: '180px', top: '-300px' }}
                overlayText="Doctor" 
                link='/doctor-login'
            />
            <InteractiveImage
                imageName='anca' 
                imagePosition={{ left: '750px', top: '300px' }} 
                textPosition={{ left: '-100px', top: '-300px' }}
                overlayText="Admin" 
                link='/admin-login'
            />
            
        </div>
        
      );

}
export default Home;
