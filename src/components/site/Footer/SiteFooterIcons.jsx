import React from 'react'
import { Link } from 'react-router-dom';
import FacebookIcon from '@mui/icons-material/Facebook';
import YouTubeIcon from '@mui/icons-material/YouTube';
import InstagramIcon from '@mui/icons-material/Instagram';

const SiteFooterIcons = () => {
  return (
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
  )
}

export default SiteFooterIcons