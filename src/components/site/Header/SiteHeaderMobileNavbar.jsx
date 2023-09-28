import React from 'react'
import {Link} from 'react-router-dom'
import Accardion from '../../Common/Accardion'
import  '../../../assets/styles/site/layout/Header.scss'



const SiteHeaderMobileNavbar = () => {
    return (
        <>
            <ul className=''>
                    <li>
                    <div class="group">
  <button class="">
    Hover et
  </button>
  
  <div class="">
    İkinci öğe
  </div>
</div>
                    </li>
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
                    <li>
                        <Accardion Title={"Blog"} Children={["blog","blog detail"]}/>
                    </li>
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
                <li><div>
      
      
  
    </div></li>

            </ul>


        </>
    )
}

export default SiteHeaderMobileNavbar