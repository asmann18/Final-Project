import axios from 'axios'
import React, { useContext, useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { Link } from 'react-router-dom'
import "../../../assets/styles/site/Login.scss"
import Logo from "../../../assets/images/logo_red.png"
import CloseIcon from '@mui/icons-material/Close';
import MainContext from '../../../contexts/MainContext'
import LogoutIcon from '@mui/icons-material/Logout';
import InventoryIcon from '@mui/icons-material/Inventory';
import PersonIcon from '@mui/icons-material/Person';
const Login = () => {
    const [email, setEmail] = useState("")
    const [password, setPassword] = useState("")
    const history = useNavigate();
    const url = "https://localhost:7066/api/Auth/Login";
    const data = useContext(MainContext)
    const [user, setUser] = useState(null)
    const [error,setError]=useState('')
 
    const closeForm = () => {
        data.setToggleLogin(!data.toggleLogin)
    }

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const res = await axios.post(url, {
                "email": email, "password": password
            })
            localStorage.setItem("tokenData", JSON.stringify(res.data.data))
            setError('')

            axios.defaults.headers.common['Authorization'] = "Bearer " + res.data.data.token;
            if (res.data.data.role == "Admin" || res.data.data.role == "Moderator") {
                history("/admin")
            } else {
                closeForm();
                history("/")
            }
        } catch (error) {
            setError('Email və ya şifrə yanlışdır.')
            console.log(error.response)
        }
    }

    const Logout = (e) => {
        // e.preventDefault()
        localStorage.clear("tokenData")
        delete axios.defaults.headers.common["Authorization"]
        closeForm()
    }
    useEffect(() => {
        axios.get("https://localhost:7066/api/Users/UserGetInfo").then(res => {
            setUser(res.data.data)
            // console.log(res.data.result.data)
        }).catch(e => {
            console.log("")
        })
    }, [])

    return (

        user ? <div className="userInfo loginForm logout">
            <div className="headerForm">
                <div className="logo">
                    <img src={Logo} alt="logo" />
                </div>
                <div className="close" onClick={closeForm}>
                    <CloseIcon />
                </div>
            </div>
            {user.role == "Admin" || user.role == "Moderator" ? <Link to={'/admin'}>
            <h2>
                <PersonIcon />
                {user.username}
            </h2>
            </Link> :             <h2>
                <PersonIcon />
                {user.username}
            </h2>}

            <h2 onClick={closeForm}><Link to={"/orders"}>
                <InventoryIcon />
                Sifarişlərim</Link></h2>
            <h2 onClick={Logout}><Link to={"/"}>
                <LogoutIcon />
                Çıxış et</Link></h2>

        </div> :
            <form className='loginForm' action="post">
                <div className="headerForm">
                    <div className="logo">
                        <img src={Logo} alt="logo" />
                    </div>
                    <div className="close" onClick={closeForm}>
                        <CloseIcon />
                    </div>
                </div>
                <h2>İstifadəçi girişi</h2>
                <span className='error'>{error}</span>
                <div className="inputGroup">
                    <input type="email" id="email" value={email} placeholder='E-mail' onChange={(e) => { setEmail(e.target.value) }} />
                </div>

                <div className="inputGroup">
                    <input type="password" id="password" placeholder='Şifrə' value={password} onChange={(e) => { setPassword(e.target.value) }} />
                </div>
                <button type='submit' onClick={handleSubmit} >Login</button>
                <div className="links">
                    <Link to={"/"}>Şifrəni unutdun?</Link>

                    <Link to={"/register"} onClick={closeForm} >Qeydiyyatdan keç</Link>
                </div>
            </form>
    )
}

export default Login