import React, { useEffect, useState } from 'react'
import Header from '../../../layout/admin/Header/Header'
import { Outlet, useParams } from 'react-router-dom'
import Error from '../../error/Error'
import Loading from '../../../components/Common/Loading'
import axios from 'axios'
const AdminRoot = () => {
  const { root } = useParams()
  const [role, setRole] = useState("")
  // const [tokenData,setTokenData]=useState(null)
  useEffect(() => {
    const tokenData =localStorage.getItem("tokenData");
    if (tokenData) {
      const parsedTokenData = JSON.parse(tokenData);
      setRole(parsedTokenData.role);
      axios.defaults.headers.common['Authorization'] = "Bearer " + JSON.parse(tokenData).token;
    } else {
      setRole("");
      axios.defaults.headers.common['Authorization'] = "" ;

    }
  }, [])

  const [isLoading, setIsLoading] = useState(true)
  useEffect(() => {
    const timer = setTimeout(() => {
      setIsLoading(false);
    }, 3000);
    return () => {
      clearTimeout(timer);
    };
  }, []);

  const Access = role === "Admin" || role === "Moderator";
  return (

    Access ? !isLoading ? < > <Header root={root} />
      <Outlet /></> : <Loading /> : <Error />




  )
}

export default AdminRoot