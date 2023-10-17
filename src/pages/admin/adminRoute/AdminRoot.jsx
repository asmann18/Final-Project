import React from 'react'
import Header from '../../../layout/admin/Header/Header'
import Footer from '../../../layout/admin/Footer/Footer'
import { Outlet, useParams } from 'react-router-dom'
const AdminRoot = () => {
  const {root}=useParams();
    return (
        <>
            <Header root={root} />
            <Outlet />

        </>
    )
}

export default AdminRoot