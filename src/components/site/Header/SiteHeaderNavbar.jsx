import React from 'react'
import { Link } from "react-router-dom";
import HoverMenu from '../../Common/HoverMenu';
import  '../../../assets/styles/site/layout/Header.scss'
import ArrowDropDownIcon from '@mui/icons-material/ArrowDropDown';
const SiteHeaderNavbar = () => {
    return (
        <>
            <ul className='siteHeaderNavbar '>
                <li>
                    <Link to={"/"}>
                        Əsas Səhifə
                    </Link>
                </li>
                <li  className='hi'>
                    <Link to={"/shop"}>
                        Mağaza<ArrowDropDownIcon/>
                    </Link>
                    <ul className="siteHeaderNavbarInfo">
                        <li>blog</li>
                        <li>blog</li>
                        <li>blog</li>
                        <li>blog</li>
                        <li>blog</li>
                    </ul>
                </li>
                <li>
                    <Link to={"/blog"}>
                        Blog<ArrowDropDownIcon/>
                    </Link>
                </li>
                <li>
                    <Link to={"/moves"}>
                        Məşq Hərəkətləri<ArrowDropDownIcon/>
                    </Link>
                </li>
                <li>
                    <Link to={"contact"}>
                        Əlaqə
                    </Link>
                </li>
              

            </ul>

        </>
    )
}

export default SiteHeaderNavbar