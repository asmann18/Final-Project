import React from 'react'
import { Link } from "react-router-dom";
const SiteHeaderNavbar = () => {
    return (
        <>
            <ul className='flex gap-12 font-bold justify-center text-base text-white'>
                <li>
                    <Link to={"/"}>
                        Əsas Səhifə
                    </Link>
                </li>
                <li>
                    <Link to={"/shop"}>
                        Mağaza
                    </Link>
                </li>
                <li>
                    <Link to={"/blog"}>
                        Bloq
                    </Link>
                </li>
                <li>
                    <Link to={"/moves"}>
                        Məşq Hərəkətləri
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