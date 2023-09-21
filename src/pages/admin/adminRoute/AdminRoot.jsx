import React from 'react'
import Header from '../../../layout/admin/Header/Header'
import Footer from '../../../layout/admin/Footer/Footer'
import { Outlet } from 'react-router-dom'
const AdminRoot = () => {
    return (
        <>
            <Header />
            <Outlet />
            <Footer />

        </>
    )
}

export default AdminRoot