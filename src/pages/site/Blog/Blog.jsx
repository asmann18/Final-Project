import React from 'react'
import BannerSlider from '../../../components/site/Common/BannerSlider'
import BlogTable from '../../../components/site/Common/BlogTable'

const Blog = () => {
  return (
    <div className='blogPage'>
      <BannerSlider content={"Blog"}/>
      <BlogTable/>
    </div>
  )
}

export default Blog