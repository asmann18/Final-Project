import React, { Component } from 'react'

import Slider from "react-slick";
// Import css files
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";

// function SampleArrow(props) {
//   const { className, style, onClick } = props;
//   return (
//     <div
//       className={className}
//       style={{ ...style, display: "block", background: "red" }}
//       onClick={onClick}
//     />
//   );
// }



const Swipper = () => {
  var settings = {
    dots: true,
    infinite: true,
    // className: "center",
    // centerMode: true,
    // centerPadding: "60px",

    
    slidesToShow: 2,
    slidesToScroll: 2,
    autoScroll: true,
    scrollSpeed: 2000,
    speed:2000,
    // lazyLoad: true,
    // nextArrow: <icon />,
    // prevArrow: <SampleArrow />,
    
    variableWidth:true,
    adaptiveHeight: true,

    responsive: [
      {
        breakpoint: 1440,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 2,
          infinite: true,
          dots: true
        }
      },
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 2,
          initialSlide: 2
        }
      },
      {
        breakpoint: 670,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1
        }
      }
    ]
  };
  return (
    <div className="moves">

      <Slider className="slider" {...settings}>

        <div className="sliderItem">
          <div className="img">
            <img src="https://res.cloudinary.com/dlilcwizx/image/upload/v1696484542/ddahv5gw9z7rn1h6hgpa.jpg" alt="" />
          </div>
          <div className="info">
            <p>Shoulder Press</p>
            <span>11.02.2022</span>
          </div>
        </div>
        <div className="sliderItem">
          <div className="img">
            <img src="https://res.cloudinary.com/dlilcwizx/image/upload/v1696569430/ddahv5gw9z7rn1h6hgpa.jpg" alt="" />
          </div>
          <div className="info">
            <p>Shoulder Press</p>
            <span>11.02.2022</span>
          </div>
        </div>
        <div className="sliderItem">
          <div className="img">
            <img src="https://res.cloudinary.com/dlilcwizx/image/upload/v1696569430/ddahv5gw9z7rn1h6hgpa.jpg" alt="" />
          </div>
          <div className="info">
            <p>Shoulder Press</p>
            <span>11.02.2022</span>
          </div>
        </div>
        <div className="sliderItem">
          <div className="img">
            <img src="https://res.cloudinary.com/dlilcwizx/image/upload/v1696569430/ddahv5gw9z7rn1h6hgpa.jpg" alt="" />
          </div>
          <div className="info">
            <p>Shoulder Press</p>
            <span>11.02.2022</span>
          </div>
        </div>

      </Slider>
    </div>

  )
}

export default Swipper