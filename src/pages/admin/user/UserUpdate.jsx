import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'

const UserUpdate = () => {
  const [roles, setRoles] = useState([])
  const [user, setUser] = useState()
  const [roleId, setRoleId] = useState(0)
  const history = useNavigate()
  useEffect(() => {
    axios.get("https://localhost:7066/api/Users/GetAllRoles").then(res => {
      setRoles(res.data.data)

    }).catch(e => {
      console.log(e);
    })
  }, [])

  useEffect(() => {
    axios.get(`https://localhost:7066/api/Users/GetUserInfoById/${id}`).then(res => {
      setUser(res.data.data)
      console.log(res.data.result.data)
    }).catch(e => {
      console.log("")
    })
  }, [])


  const changeROleAsync = async (e) => {
    e.preventDefault()
    try {
      var response = await axios.post('https://localhost:7066/api/Users/ChangeUserRole', { 'userId': id, 'roleId': roleId });
      history(-1)
    } catch (e) {
      console.log(e);
    }
  }

  const { id } = useParams("id")
  return (
    <div className="AdminPanelForm">
      <h2>Update User Role</h2>
      <form action='post' className='productCreate adminCreate'>

        <div className="userInfoName">{user?.username}</div>
        <select name="AromaId" id="aromaId" onChange={(e) => setRoleId(e.target.value)}>
          <option selected disabled>{user?.role}</option>
          {roles.map((role, i) => {
            return <option key={i} value={role.id}>{role.name}</option>
          })}
        </select>

        <button onClick={changeROleAsync} type='submit'>
          Update
        </button>

      </form>
    </div>
  )
}

export default UserUpdate