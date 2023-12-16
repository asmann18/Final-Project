import axios from 'axios'
import React, { useEffect, useState } from 'react'

const SiteFooterCategories = () => {
  const [categories, setCategories] = useState([])

  useEffect(() => {
    axios.get("https://localhost:7066/api/ProductCategories/GetAllProductCategories").then(res => {
      setCategories(res.data.data);
    })
  }, [])
  return (
    <div className='categories' >
      <h3>Ünvanlar</h3>
      <ul>
        <li>BAKI şəh., Gənclik m/s, Caspian Shopping Centre, Gənclik Mall-a üzbəüz</li>
        <li>BAKI şəh., Əhmədli m/s, Saraevo küç. 1</li>
        <li>BAKI şəh., Bakıxanov(Razin) qəsəbəsi, Aygün Mall</li>
        <li>SUMQAYIT şəh., Sülh küc., Şaurma N 1 yaxınlığında</li>
        <li>GƏNCƏ şəh., Cavadxan küç. 45</li>

      </ul>
    </div>
  )
}

export default SiteFooterCategories