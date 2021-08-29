import React from 'react'
import NumberFormat from 'react-number-format'
import TextField from '@material-ui/core/TextField'

interface CvcNumberFormatCustomProps {
  inputRef: (instance: NumberFormat | null) => void
  onChange: (event: { target: { name: string; value: string } }) => void
  name: string
}

const CvcNumberFormatCustom: React.FC<CvcNumberFormatCustomProps> = ({
  inputRef,
  onChange,
  name,
  ...otherProps
}: CvcNumberFormatCustomProps) => (
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
    format="####"
  />
)

interface CvcNumberTextFieldProps {
  cvcNumber: string
  onCvcNumberChange: (e: React.ChangeEvent<HTMLInputElement>) => void
}

const CvcNumberTextBox: React.FC<CvcNumberTextFieldProps> = ({
  cvcNumber,
  onCvcNumberChange,
}: CvcNumberTextFieldProps) => {
  return (
    <TextField
      required
      fullWidth
      id="input-cvc"
      data-testid="input-cvc"
      label="CVC"
      value={cvcNumber}
      onChange={onCvcNumberChange}
      name=""
      variant="outlined"
      InputProps={{
        style: { fontSize:'1.5em' },                  
        inputComponent: CvcNumberFormatCustom as any,
      }}
    />
  )
}

export default CvcNumberTextBox
