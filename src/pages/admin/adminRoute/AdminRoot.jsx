import React from 'react'
import Header from '../../../layout/admin/Header/Header'
import Footer from '../../../layout/admin/Footer/Footer'
import { Outlet } from 'react-router-dom'
const AdminRoot = () => {
    return (
        <>
            <Header />
            <Outlet />

        </>
    )
}

export default AdminRoot