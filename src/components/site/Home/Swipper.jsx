import React, { Component, useEffect, useState } from 'react'
import CalendarTodayIcon from '@mui/icons-material/CalendarToday';
import Slider from "react-slick";
// Import css files
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import axios from 'axios';
import { Link } from 'react-router-dom';

function SampleArrow(props) {
  const { className, style, onClick } = props;
  return (
    <div
      className={className}
      style={{ ...style, display: "block", border:"none",padding:"1px 5px 1px 1px",borderRadius:"100%",background:"crimson" }}
      onClick={onClick}
    />
  );
}



const Swipper = () => {

  const[moves,setMoves]=useState([])

useEffect(()=>{
  axios.get("https://localhost:7066/api/Moves/GetAllMoves").then(res=>{
    setMoves(res.data.data)
  })
},[])

  var settings = {
    dots: true,
    infinite: true,
    slidesToShow: 2,
    slidesToScroll: 2,
    autoScroll: true,
    scrollSpeed: 2000,
    speed:2000,
    prevArrow: <SampleArrow />,
    nextArrow: <SampleArrow />,
    
    variableWidth:true,
    adaptiveHeight: true,

    responsive: [
      {
        breakpoint: 1440,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 2,
          infinite: true,
          dots: true,
          slidesToScroll: 2,
    autoScroll: true,
    scrollSpeed: 2000,
    speed:2000,
        }
      },
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 1,
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
  var settings2={
    dots: true,
    infinite: true,
    slidesToShow: 2,
    slidesToScroll: 2,
    autoplay: true, 
    autoplaySpeed: 5000, 
    speed: 2000,
    prevArrow: <SampleArrow />,
    nextArrow: <SampleArrow />,
    variableWidth: true,
    adaptiveHeight: true,
  }
  return (
    <div className='HomeMovesSection'>
    <h2>
      Məşq Hərəkətləri
    </h2>
    <div className="moves">
      <Slider className="slider" {...settings2}>
{moves.slice(0,8).map((move,i)=>{
  return(   <Link to={`/moves/${move.id}`} key={i} className="sliderItem">
  <div className="img">
    <img src={move.moveImagePaths[0]} alt="move" />
  </div>
  <div className="info">

    <p>{move.name.substring(0,20)}</p>
    <span><CalendarTodayIcon/> {move.modifiedTime.substring(0,10)}</span>
  </div>
</Link>)
})}
     

      </Slider>
    </div>
    </div>

  )
}

export default Swipper