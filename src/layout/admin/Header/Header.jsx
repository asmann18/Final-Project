import React from 'react'
import '../../../assets/styles/admin/layout/Header.scss'
import AdminHeaderTop from '../../../components/admin/Header/AdminHeaderTop'
import AdminHeaderBottom from '../../../components/admin/Header/AdminHeaderBottom'

const Header = () => {
  return (
    <header className='adminHeader'>
    <AdminHeaderTop/>
    <AdminHeaderBottom/>
    </header>
  )
}

export default Header