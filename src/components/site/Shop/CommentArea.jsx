import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
import PersonIcon from '@mui/icons-material/Person';
import DeleteIcon from '@mui/icons-material/Delete';
import StarRateIcon from '@mui/icons-material/StarRate';
import Box from '@mui/material/Box';
import Rating from '@mui/material/Rating';
import Typography from '@mui/material/Typography';
import { Event, Try } from '@mui/icons-material';

const CommentArea = () => {
  const [rating, setRating] = useState(0)
  const [comments, setComments] = useState([])
  const [commentText, setCommentText] = useState('')
  const [dummyRefresh,setDummyRefresh]=useState(0)
  const [error,setError]=useState("")

  const { id } = useParams("id")
  useEffect(() => {
    axios.get(`https://localhost:7066/api/Comments/GetComments/${id}`).then(res => {
      setComments(res.data.data)
    }).catch(e => {
      console.log(e);
    })
  }, [dummyRefresh])




  const removeComment=async (commentId)=>{
    try {
      const response = await axios.delete(`https://localhost:7066/api/Comments/DeleteComment/${commentId}`)

      setDummyRefresh(dummyRefresh+1)
      setCommentText('');
      setRating(0)

    } catch (e) {
      console.log(e);
    }
  }

  const postComment = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('https://localhost:7066/api/Comments/AddComment', {
        "text": commentText,
        "rating": rating,
        "productId": id,
      })
      setDummyRefresh(dummyRefresh+1)
      setCommentText('');
      setRating(0)
      setError('')

    } catch (e) {
      setError("Şərh yazmaq üçün ilk öncə məhsulu satın almalısınız")
      console.log(e);
    }
  }

  return (
    <div className="commentArea">
      <ul className="comments">
        {comments ? comments.length > 0 ? comments.map((comment, i) => {
          return (<li key={i}>
            <div className="comment">
              <p>
                <PersonIcon />
                {comment.createdBy}
              </p>
              <span className='commentText'>{comment.text}</span>
              <span className='commentRating'>
              <Rating name="read-only" value={comment.rating} readOnly />

              </span>

            </div>
            <span className='commentActions'>
              <div className="reply">reply</div>
              <div onClick={()=>{
                removeComment(comment.id)
              }} className="deleteIcon">
                <DeleteIcon />
              </div>

            </span>
          </li>)
        }) : "Şərh yazılmayıb" : ""}
      </ul>
      <div className="form">
        <h2>Şərh yazın</h2>
        <form >
          <span className='error'>{error}</span>
          <textarea onChange={(e) => { setCommentText(e.target.value) }} value={commentText} type="text" placeholder='Şərhinizi daxil edin*' />
          <div className="rating">
            <Typography component="legend">Reytinq</Typography>
            <Rating
              name="simple-controlled"
              value={rating}
              onChange={(event, newValue) => {
                setRating(newValue);
              }}
            />
          </div>
          <button onClick={postComment}>Göndər</button>
        </form>
      </div>
    </div>
  )
}

export default CommentArea