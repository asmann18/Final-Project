import axios from 'axios'
import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { Link } from 'react-router-dom'
import "../../../assets/styles/site/Login.scss"
const Login = () => {
    const [email, setEmail] = useState("")
    const [password, setPassword] = useState("")
    const history = useNavigate();
    const url = "https://localhost:7066/api/Auth/Login";


    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const res = await axios.post(url, {
                "email": email, "password": password
            })
            console.log(res.data)
            localStorage.setItem("tokenData", JSON.stringify(res.data.data))
            if (res.data.data.role == "Admin" || res.data.data.role == "Moderator") {
                history("/admin")
            } else {
                history("/")
            }
        } catch (error) {
            console.log(error.response)
        }
    }


    return (<form className='loginForm' action="post">
        <h2>İstifadəçi girişi</h2>
        <div className="inputGroup">
            <input type="email" id="email" value={email} placeholder='E-mail' onChange={(e) => { setEmail(e.target.value) }} />
        </div>

        <div className="inputGroup">
            <input type="password" id="password" placeholder='Şifrə' value={password} onChange={(e) => { setPassword(e.target.value) }} />
        </div>
        <button type='submit' onClick={handleSubmit} >Login</button>
        <div className="links">
            <Link to={"/"}>Şifrəni unutdun?</Link>
            
            <Link to={"/"}>Qeydiyyatdan keç</Link>
        </div>
    </form>
    )
}

export default Login