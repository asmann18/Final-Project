import React from 'react'
import FacebookIcon from '@mui/icons-material/Facebook';
import YouTubeIcon from '@mui/icons-material/YouTube';
import InstagramIcon from '@mui/icons-material/Instagram';
import PhoneEnabledIcon from '@mui/icons-material/PhoneEnabled';
import LocationOnIcon from '@mui/icons-material/LocationOn';
import { Input } from 'antd';
import { Link } from 'react-router-dom'
import  '../../../assets/styles/site/layout/Header.scss'

const SiteHeaderInfoIcons = () => {
    return (
        <section className='siteHeaderInfoIcons'>
            <ul className="icons">

                <li className=''>
                    <Link>
                        <FacebookIcon />
                    </Link>
                </li>
                <li className=''>
                    <Link>
                        <InstagramIcon />
                    </Link>
                </li>
                <li className=''>
                    <Link>
                        <YouTubeIcon />
                    </Link>
                </li>
            </ul>

            <div className="contact">
                <div className="phoneIcon">

                <PhoneEnabledIcon  />
                </div>
                <p className=''>+994 51 434 15 23</p>
                <div className="locations ">
                <LocationOnIcon />
                <p>Ünvanlarımız</p>
                </div>
            </div>
            <div className="searchInput ">
                <Input className='input' placeholder="Məhsul axtarın" />
            </div>
        </section>
    )
}

export default SiteHeaderInfoIcons