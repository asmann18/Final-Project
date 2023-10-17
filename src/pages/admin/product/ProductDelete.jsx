import React from 'react'
import { useParams } from 'react-router-dom'

const ProductDelete = () => {
    const {id}=useParams()
  return (
    <div>ProductDelete {id}</div>
  )
}

export default ProductDelete