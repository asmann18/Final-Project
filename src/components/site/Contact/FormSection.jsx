import React, { useState } from 'react'
import WatchLaterIcon from '@mui/icons-material/WatchLater';
import FacebookIcon from '@mui/icons-material/Facebook';
import YouTubeIcon from '@mui/icons-material/YouTube';
import InstagramIcon from '@mui/icons-material/Instagram';
import { Link } from 'react-router-dom';
import PhoneIcon from '@mui/icons-material/Phone';
import EmailIcon from '@mui/icons-material/Email';

const FormSection = () => {

    const [name, setName] = useState("")
    const [email, setEmail] = useState("")
    const [subject, setSubject] = useState("")
    const [content, setContent] = useState("")
    const HandleForm = (e) => {
        e.preventDefault();
        setContent("")
        setName("")
        setEmail("")
        setSubject("")
    }

    return (
        <div className="formSection">

            <form action="post" className="form">
                <input type="text" className='name' value={name} onChange={(e) => { setName(e.target.value) }} placeholder='Adınız' />
                <input type="email" className='email' value={email} onChange={(e) => { setEmail(e.target.value) }} placeholder='E-mail' />
                <input type="text" className="subject" value={subject} onChange={(e) => { setSubject(e.target.value) }} placeholder='Məzmun' />
                <input type="text" className="content" value={content} onChange={(e) => { setContent(e.target.value) }} placeholder='Təklif və iradınız' />
                <button type='submit' onClick={HandleForm}>BAASSĞĞĞ</button>
            </form>
            <div className="info">
                <div className="details">
                    <div className="detail">
                        <p>
                            <WatchLaterIcon /> İş vaxtı: 10:00-21:00
                        </p>
                        <p>
                            <Link>
                                <FacebookIcon />
                            </Link>
                            <Link>
                                <YouTubeIcon />
                            </Link>
                            <Link>
                                <InstagramIcon />
                            </Link>
                        </p>
                    </div>
                    <div className="detail">
                        <p>
                            <PhoneIcon /> +994 51 434 1523
                        </p>
                    </div>
                    <div className="detail">
                        <p>
                            <EmailIcon /> atlet.az@gmail.com
                        </p>
                    </div>
                </div>
                <ul className="locations">
                    <li><strong>BAKI</strong> şəh., Gənclik m/s, Caspian Shopping Centre, Gənclik Mall-a üzbəüz</li>
                    <li><strong>BAKI</strong> şəh., Əhmədli m/s, Saraevo küç. 1</li>
                    <li><strong>BAKI</strong> şəh., Bakıxanov(Razin) qəsəbəsi, Aygün Mall</li>
                    <li><strong>BAKI</strong> şəh., Memar Əcəmi m/s, 3-cü mikrorayon dairəsindən Əcəmi metrosuna gedən yolun sağında</li>
                    <li><strong>BAKI</strong> şəh., Sülh küc., Şaurma N 1 yaxınlığında</li>
                    <li><strong>BAKI</strong> şəh., Cavadxan küç. 45</li>
                </ul>
            </div>
        </div>
    )
}

export default FormSection