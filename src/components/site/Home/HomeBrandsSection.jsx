import Slider from 'react-slick';
import 'slick-carousel/slick/slick.css';
import 'slick-carousel/slick/slick-theme.css';
import { useEffect, useState } from 'react';
import axios from 'axios';


function SampleArrow(props) {
  const { className, style, onClick } = props;
  return (
    <div
      className={className}
      style={{ ...style, display: "none" }}
      onClick={onClick}
    />
  );
}

const HomeBrandsSection = () => {
  const settings = {
    dots: false, 
    infinite: true, 
    speed: 10000, 
    slidesToShow: 1,
    slidesToScroll: 4,
    autoplay: true, 
    autoplaySpeed: 200,
    prevArrow: <SampleArrow />,
    nextArrow: <SampleArrow />,
    variableWidth:true,
    adaptiveHeight: true,
  };
  
  const [brands,setBrands]=useState([])
  useEffect(()=>{
    axios.get("https://localhost:7066/api/Brands/GetAllProducts").then(res=>{
      setBrands(res.data.data)
    })
  },[])
  return (
    <div className='brandsSlider'>
      <Slider {...settings}>
        {brands.map((brand,index)=>{
          return (  <div className='sliderItem' key={index}>
            <img src={brand.image.path} alt="Resim 1" />
          </div>)
        })}
      
      </Slider>
    </div>
  );
};

export default HomeBrandsSection