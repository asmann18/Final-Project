import React from 'react'
import FacebookIcon from '@mui/icons-material/Facebook';
import YouTubeIcon from '@mui/icons-material/YouTube';
import InstagramIcon from '@mui/icons-material/Instagram';
import PhoneEnabledIcon from '@mui/icons-material/PhoneEnabled';
import LocationOnIcon from '@mui/icons-material/LocationOn';
import { Input } from 'antd';
import { Link } from 'react-router-dom'
const SiteHeaderInfoIcons = () => {
    return (
        <section className='flex gap-20 mr-5 ml-5 p-5 text-white pt-1 border-b border-gray-50 pb-1 items-center'>
            <ul className="icons flex opacity-80">

                <li className='p-1'>
                    <Link>
                        <FacebookIcon />
                    </Link>
                </li>
                <li className='p-1'>
                    <Link>
                        <InstagramIcon />
                    </Link>
                </li>
                <li className='p-1'>
                    <Link>
                        <YouTubeIcon />
                    </Link>
                </li>
            </ul>

            <div className="contact flex">
                <PhoneEnabledIcon />
                <p className='mr-5'>+994 51 434 15 23</p>
                <LocationOnIcon />
                <p>Ünvanlarımız</p>
            </div>
            <div className="searchInput">
                <Input className='bg-gray-300' placeholder="Məhsul axtarın" />
            </div>
        </section>
    )
}

export default SiteHeaderInfoIcons