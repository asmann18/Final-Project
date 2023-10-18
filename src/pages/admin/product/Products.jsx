import axios from 'axios'
import React, { useEffect, useState } from 'react'
import TableComponent from '../../../components/Common/AdminPanelTable';
import AdminPanelTable from '../../../components/Common/AdminPanelTable';
import '../../../assets/styles/admin/AdminPanel.scss'
import { Link } from 'react-router-dom';
const Products = () => {
    const [products, setProducts] = useState([])
    useEffect(() => {
        axios.get('https://localhost:7066/api/Products/GetAllProducts').then(res => {
            setProducts(res.data.data);
        }).catch(error => {
            console.error(error);
        });
    }, []);
    let rows = []
    const columns = [
        { id: "id", label: "Id", minWidth: 20,maxWidth:200 },
        { id: "image", label: "Image", minWidth: 20,maxWidth:200 },
        { id: "name", label: "Name", minWidth: 20,maxWidth:200 },
        { id: "price", label: "Price", minWidth: 20,maxWidth:200 },
        { id: "buttons", label: "Actions", minWidth: 20,maxWidth:200 },
    ];

    products.map((product) => {
        rows.push({ id: product.id, name: product.name, price: product.price,image:product.productImagePaths[0],buttons:{detail:`/admin/products/${product.id}`,update:`/admin/products/update/${product.id}`,delete:`/admin/products/delete/${product.id}`} })
    })



    return (
        <div className='products adminList'>
            <div className="listInfo">
            <h2>Products</h2>
            <div className="add">
                <Link className='btn btn-success' to={"create"}>Create</Link>
            </div>
            </div>
            <ul className='list'>
                <AdminPanelTable Rows={rows} Columns={columns} />
            </ul>
         
        </div>
    )
}

export default Products