import React, { useContext, useEffect, useState } from 'react'
import CheckCircleIcon from '@mui/icons-material/CheckCircle';
import ClearIcon from '@mui/icons-material/Clear';
import MainContext from '../../../contexts/MainContext';
import PersonIcon from '@mui/icons-material/Person';
import EmailIcon from '@mui/icons-material/Email';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import Error from '../../../pages/error/Error'
import Loading from '../../Common/Loading';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const PaymentModal = () => {
  const notify = () => toast.success("Səbətə uğurla əlavə olundu");

  const data = useContext(MainContext)
  const [userInfo, setUserInfo] = useState(null)
  const [isDelivery, setIsDelivery] = useState(false)
  const history = useNavigate()
  const [isLoading, setIsloading] = useState(true)
  const [location,setLocation]=useState('')
  useEffect(() => {

    axios.get('https://localhost:7066/api/Users/UserGetInfo').then(res => {
      setUserInfo(res.data.data)
      setIsloading(false)
    }).catch(e => {
      closePayment()
      history("register")
    })
  }, [])
  const closePayment = () => {
    data.setTogglePayment(false)
  }

const Buy=async ()=>{
  try{

    if(isDelivery)
    {
   const response=await axios.get(`https://localhost:7066/api/BasketItems/BuyTheBasket?location=${location}`) 
   notify()
   history('/shop',{toastify:true})
   
  }
  else{
    const response=await axios.get('https://localhost:7066/api/BasketItems/BuyTheBasket')
    notify()
    history('/shop',{toastify:true})
    
  }
}catch(e){
  console.log(e);
}
}

  return (
    <div className='paymentModal'>
      <ToastContainer />

      <div className="head"><p className='checkIcon'><CheckCircleIcon />Sifarişi tamamla</p><p onClick={closePayment} className='closeIcon'><ClearIcon /></p></div>

      {!isLoading ?
        <div className="body">
          <div className="userInfo">
            <div className="infoGroup"><PersonIcon />
              <p>{userInfo.fullname}</p>
            </div>
            <div className="infoGroup"><EmailIcon />
              <p>{userInfo.email}</p>
            </div>
          </div>
          <div className="delivery">
            <div className="inputGroupCheck">
              <input type="checkbox" id='deliveryCheck' className='checkDelivery' value={isDelivery} onChange={() => { setIsDelivery(!isDelivery) }} />
              <label htmlFor="deliveryCheck">Çatdırılma</label>
            </div>
            {isDelivery ? <div className="inputGroup location">
              <input minLength={3} maxLength={60} type="text" placeholder='Ünvanı daxil edin' value={location} onChange={(e)=>{setLocation(e.target.value)}} />
              <div className="comment">
                <span>Qeyd:Çatdırılma 5 azn</span>
                <span>Rayonlara çatdırılma mövcuddur</span>

              </div>
            </div>
              : <h3 >Mağazadan götürmə</h3>}
          </div>
          <div className="button">
            <button onClick={Buy}>BASSĞĞĞ</button>
          </div>
        </div>
        : <Loading />}
    </div>
  )
}

export default PaymentModal