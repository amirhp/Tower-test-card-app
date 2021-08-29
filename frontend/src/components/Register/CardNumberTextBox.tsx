import React from 'react'
import NumberFormat from 'react-number-format'
import TextField from '@material-ui/core/TextField'

interface CardNumberFormatCustomProps {
  inputRef: (instance: NumberFormat | null) => void
  onChange: (event: { target: { name: string; value: string } }) => void
  name: string
}

const CardNumberFormatCustom: React.FC<CardNumberFormatCustomProps> = ({
  inputRef,
  onChange,
  name,
  ...otherProps
}: CardNumberFormatCustomProps) => (
  <NumberFormat
    {...otherProps}
    getInputRef={inputRef}
    
    onValueChange={(values): void => {
      onChange({
        target: {
          name,
          value: values.value,
        },
      })
    }}
    format="#### #### #### ####"
    mask="-"
  />
)

interface CardNumberTextFieldProps {
  cardNumber: string
  onCardNumberChange: (e: React.ChangeEvent<HTMLInputElement>) => void
}

const CardNumberTextBox: React.FC<CardNumberTextFieldProps> = ({
  cardNumber,
  onCardNumberChange,
}: CardNumberTextFieldProps) => {
  return (
    <TextField
      required
      fullWidth
      id="input-cardNumber"
      data-testid="input-cardNumber"
      label="Credit Card Number"
      value={cardNumber}
      onChange={onCardNumberChange}
      name="cardNumer"
      InputProps={{
        style: { fontSize:'1.5em' },                  
        inputComponent: CardNumberFormatCustom as any,
      }}
      variant="outlined"
    />
  )
}

export default CardNumberTextBox
