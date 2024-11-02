import React, { useState } from 'react'
import { Rating } from 'react-simple-star-rating'
import { useEffect } from "react"

export function AvaliacaoEstrelas() {
  const [rating, setRating] = useState(0)

  const handleRating = (rate) => {
    setRating(rate)
  }

  return (
    <div>
      <Rating 
          onClick={handleRating} initialValue={rating} 

        />
    </div>
    
  )
}