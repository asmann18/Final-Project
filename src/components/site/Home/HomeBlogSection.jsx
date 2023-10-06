import React from 'react'
import BlogImages from '../../../assets/images/berpa.jpg'
import { Link } from 'react-router-dom'

const HomeBlogSection = () => {
    return (
        <div className='blogSection bgRed'>
            <div className="txt"><h2>Bloqlar</h2></div>
            <div className="blogs">
                <div className="blog">
                    <div className="image">
                        <img src={BlogImages} alt="" />
                    </div>
                    <div className="info">
                        <p className='blogName'>Blog</p>
                        <span className='blogDescription'>hi this is blog</span>
                    </div>
                </div>
                <div className="blog">
                    <div className="image">
                        <img src={BlogImages} alt="" />
                    </div>
                    <div className="info">
                        <p className='blogName'>Blog</p>
                        <span className='blogDescription'>hi this is blog</span>
                    </div>
                </div>
                <div className="blog">
                    <div className="image">
                        <img src={BlogImages} alt="" />
                    </div>
                    <div className="info">
                        <p className='blogName'>Blog</p>
                        <span className='blogDescription'>hi this is blog</span>
                    </div>
                </div>
            </div>
            <div className="button">
                <button><Link to={"/blog"}>Read More</Link></button>
            </div>
        </div>

    )
}

export default HomeBlogSection