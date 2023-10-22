import axios from 'axios'
import React, { useEffect, useState } from 'react'
import Icon from '@mui/icons-material/FitnessCenter';
import { Link } from 'react-router-dom';
import NotFound from './NotFound';

const SiteTable = () => {
    const [parts, setParts] = useState([])
    const [moves, setMoves] = useState([])
    const [active, setActive] = useState(4)


    useEffect(() => {
        axios.get('https://localhost:7066/api/Parts/GetAllParts').then(res => {
            setParts(res.data.data)
            axios.get(`https://localhost:7066/api/Parts/GetAllMovesByPartId/${res.data.data[0].id}`).then(response => {
                setMoves(response.data.data)
                setActive(response.data.data[0].id)

            })
        }).catch(e => {
            console.log(e)
        })
    }, [])

    const SwitchMoves = async (e, id) => {
        e.preventDefault();
        try {
            const response = await axios.get(`https://localhost:7066/api/Parts/GetAllMovesByPartId/${id}`)
            setMoves(response.data.data)
            setActive(id)
        }
        catch (err) {
            console.log(err)
        }
    }
    return (

        <div className='siteTable'>
            <ul onLoad={(e) => { SwitchMoves(e, active) }} className="columns">
                {parts.map((part, i) => {
                    return <li className={part.id === active ? "active" : ""} onClick={(e) => SwitchMoves(e, part.id)} key={i}>
                        <div className="img"><img src={part.image.path} alt="" /></div>
                        <p>{part.name}</p>
                    </li>
                })}
            </ul>
            <ul className="rows">
                {moves.length>0 ? moves.map((move, i) => {
                    return <Link to={`${move.id}`} key={i}>
                        <Icon />
                        <p>{move.name}</p>
                    </Link>
                }) : <NotFound/>}
            </ul>
         

        </div>
    )
}

export default SiteTable