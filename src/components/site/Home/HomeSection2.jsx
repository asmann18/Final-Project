import React from 'react'
import ArrowImage from '../../../assets/images/right_arrow.png'
import SliderPhoto1 from '../../../assets/images/boy.png'
import SliderPhoto2 from '../../../assets/images/man.png'
import SliderPhoto3 from '../../../assets/images/man2.png'
import { Link } from 'react-router-dom'
const   HomeSection2 = () => {
  return (
    <div className='sliderSection'>
        <Link to={"/moves"} className="slider">
            <div className="txt">
                <span>01</span>
                <p>Məşq</p>
                <img src={ArrowImage} alt="" />
            </div>
            <div className="img">
                <img src={SliderPhoto1} alt="" />
            </div>
        </Link>
        <Link to={"/shop"} className="slider">
            <div className="txt">
                <span>02</span>
                <p>İdman Qidaları</p>
                <img src={ArrowImage} alt="" />
            </div>
            <div className="img">
                <img src={SliderPhoto2} alt="" />
            </div>
        </Link>
        <Link to={"/blog"} className="slider">
            <div className="txt">
                <span>03</span>
                <p>Sağlamlıq</p>
                <img src={ArrowImage} alt="" />
            </div>
            <div className="img">
                <img src={SliderPhoto3} alt="" />
            </div>
        </Link>
    </div>
  )
}

export default HomeSection2