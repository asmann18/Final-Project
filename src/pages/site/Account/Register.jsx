import React, { useState } from 'react'
import Logo from '../../../assets/images/logo_red.png'
import axios from 'axios'
import { useNavigate } from 'react-router-dom'
import "../../../assets/styles/site/Login.scss"

const Register = () => {
    const [fullname, setFullname] = useState("")
    const [username, setUsername] = useState("")
    const [email, setEmail] = useState("")
    const [password, setPassword] = useState("")
    const [passwordConfirm, setPasswordconfirm] = useState("")
    const url = "https://localhost:7066/api/Users/Register";

    const [errors,setErrors]=useState([])

    const history=useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try{
            const response=await axios.post(url,{
                fullname,username,email,password,passwordConfirm
            })
            history("/")
        }catch(error){
            console.log(error.response)
            setErrors(error.response)
        }
    
    
    }

    return (
        <div className="registerSection">
            <div className="info">
                <div className="img"><img src={Logo} alt="logo" /></div>
                <h2>Xoş Gəlmisiniz</h2>
                <p>Saytımızdan daha dolğun istifadə etmək üçün qeydiyyatdan keçin</p>
            </div>

            <form action="" className="registerForm">
                <input type="text" className="fullname" placeholder='Ad,Soyad' value={fullname} onChange={(e)=>{setFullname(e.target.value)}} />
                <input type="text" className="username" placeholder='İstifadəçi adı' value={username} onChange={(e)=>{setUsername(e.target.value)}} />
                <input type="email" className="email" placeholder='E-mail' value={email} onChange={(e)=>{setEmail(e.target.value)}} />
                <input type="password" className="password" placeholder='Şifrə' value={password} onChange={(e)=>{setPassword(e.target.value)}} />
                <input type="password" className="confirmPassword" placeholder='Yenidən şifrə' value={passwordConfirm} onChange={(e)=>{setPasswordconfirm(e.target.value)}} />
                
                <p>Saytımızı istifadə etməklə siz bizim <a href="">Gizlilik</a> siyasətimiz ilə razılaşırsınız</p>

                <button type='submit' onClick={handleSubmit} >Qeydiyyatdan keç</button>

            </form>
        </div>
    )
}

export default Register