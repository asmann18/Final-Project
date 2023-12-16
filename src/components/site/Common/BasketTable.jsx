import axios from 'axios'
import DeleteIcon from '@mui/icons-material/Delete';
import React, { useContext, useEffect, useState } from 'react'
import { Link } from 'react-router-dom';
import CartEmpty from './CartEmpty';
import PaymentModal from './PaymentModal';
import MainContext from '../../../contexts/MainContext';

const BasketTable = () => {
    const [basketItems, setBasketItems] = useState([])
    const [totalPrice, setTotalPrice] = useState(0)
    const [user, setUser] = useState(null)
    const data = useContext(MainContext)
    const [token, setToken] = useState(axios.defaults.headers.get["Authorization"])
    useEffect(() => {

        axios.get("https://localhost:7066/api/Users/UserGetInfo").then(res => {
            setUser(res.data.data)
        }).catch(e => {
            console.log(e)
        })



        setToken(axios.defaults.headers.get["Authorization"])
        axios.get('https://localhost:7066/api/BasketItems/GetBasket').then(res => {
            setBasketItems(res.data.data)
            setTotalPrice(0)

        }).catch(e => {
            console.log(e)
            setToken('')
        })
    }, [token])


    const RemoveBasket = async (e, id) => {
        // e.preventDefault()
        try {
            const response = await axios.delete(`https://localhost:7066/api/BasketItems/DeleteToBasket/${id}`)
            setBasketItems((prevItems) => prevItems.filter(item => item.id !== id));
        }
        catch (e) {
            console.log(e)
        }
    }
    useEffect(() => {
        const calculatedTotalPrice = basketItems.reduce((total, item) => {
            return total + item.product.price * item.count;
        }, 0);

        setTotalPrice(calculatedTotalPrice);
    }, [basketItems]);

    const togglePayment = (e) => {
        e.preventDefault();
        data.setTogglePayment(!data.togglePayment)
    }
    return (
        basketItems.length > 0 ?

            (<div className='basketItems'>
                {
                    data.togglePayment ? <PaymentModal /> : ""
                }

                <div className="basketItemsLeft">

                    <div className="tableHeader">
                        Səbətdəki məhsullar
                    </div>
                    <div className="table">
                        <ul className="columns">
                            <li>Məhsul şəkli</li>
                            <li>Məhsul adı</li>
                            <li>Say</li>
                            <li>Endirim</li>
                            <li>Ödəniş</li>
                            <li>Silmək</li>
                        </ul>
                        <ul className="rows">

                            {basketItems.map((basketItem, i) => {
                                return (<ul key={i}>
                                    <Link to={`/productDetail/${basketItem.product.id}`} className='img'><img src={basketItem.product.productImagePaths[0]} alt="product" /></Link>
                                    <Link to={`/productDetail/${basketItem.product.id}`} className='name'>{basketItem.product.name}</Link>
                                    <li className='productCount'>{basketItem.count}</li>
                                    <li className='discount'>{basketItem.discount}5</li>
                                    <li className='price'>{basketItem.count * basketItem.product.price}</li>
                                    <li onClick={(e) => { RemoveBasket(e, basketItem.id) }} className='delete'><DeleteIcon /></li>
                                </ul>)
                            })}
                        </ul>
                    </div>
                </div>
                <div className="basketItemsRight">
                    <div className="info">
                        <div className="count">
                            {basketItems.length} Məhsul
                        </div>
                        <div className="price">
                            <p>Ödəniləcək Məbləğ</p>
                            <span>{totalPrice} $</span>
                        </div>
                        <button onClick={togglePayment} className='btn btn-success'>Alışverişi tamamla</button>
                    </div>
                </div>
            </div>) : <CartEmpty />
    )
}

export default BasketTable