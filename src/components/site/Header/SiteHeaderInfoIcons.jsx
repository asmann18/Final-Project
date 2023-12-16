import React, { useEffect, useState } from 'react'
import FacebookIcon from '@mui/icons-material/Facebook';
import YouTubeIcon from '@mui/icons-material/YouTube';
import InstagramIcon from '@mui/icons-material/Instagram';
import PhoneEnabledIcon from '@mui/icons-material/PhoneEnabled';
import LocationOnIcon from '@mui/icons-material/LocationOn';
import NotFound from '../Common/NotFound';
import { Input } from 'antd';
import { Link } from 'react-router-dom'
import '../../../assets/styles/site/layout/Header.scss'
import axios from 'axios';

const SiteHeaderInfoIcons = () => {


    const [isSearch, setIsSearch] = useState(false)
    const [search, setSearch] = useState("")
    const [products, setProducts] = useState([])

    useEffect(() => {
        axios.get(`https://localhost:7066/api/Products/GetAllProducts?search=${search}`).then(res => {
            setProducts(res.data.data)
        }).catch(e => {
            setProducts([])
            console.log(e)
        })
    }, [search])



    const HandleFocus = () => {
        setIsSearch(true)
    }
    const HandleBlur = () => {
        const timer = setTimeout(() => {
            setIsSearch(false)
          }, 500); 
          return () => {
            clearTimeout(timer);
          };
    }
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

                    <PhoneEnabledIcon />
                </div>
                <p className=''>+994 51 434 15 23</p>
                <div className="locations ">
                    <LocationOnIcon />
                    <p>Ünvanlarımız</p>
                </div>
            </div>
            <div className="searchInput ">
                <Input onFocus={HandleFocus} onBlur={HandleBlur} value={search} onChange={(e) => { setSearch(e.target.value) }} className='input' placeholder="Məhsul axtarın" />
                {isSearch ? <div className="products">
                    {products.length>0? products.map((product, i) => {
                        return <Link to={`/productDetail/${product.id}`} className="product">
                            <div className="img">
                                <img src={product.productImagePaths[0]} alt="" />
                            </div>
                            <div className="text">
                            <p>{product.name}</p>
                            </div>

                        </Link>
                    }) : <NotFound/>}
                </div> :""}
            </div>
        </section>
    )
}

export default SiteHeaderInfoIcons