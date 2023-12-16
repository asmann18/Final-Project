import React, { useState } from 'react'
import BannerSlider from '../../../components/site/Common/BannerSlider'
import FormSection from '../../../components/site/Contact/FormSection';
import '../../../assets/styles/site/Contact.scss'
import ContactMap from '../../../components/site/Contact/ContactMap';
const Contact = () => {

  
  return (
    <div className='contactPage'>
      <BannerSlider content={"ƏLAQƏ"} />
      <div className="contactPageBody">
        <FormSection />
        <ContactMap/>

      </div>
    </div>
  )
}

export default Contact