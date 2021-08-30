import React from 'react'
import { render, RenderResult, fireEvent, act } from '@testing-library/react'
import RegisterForm, { RegisterProps } from './Register'
import CreditCard from '../../models/CreaditCard'

describe('Register Component', () => {
  const onSubmitClicked: (data: CreditCard) => Promise<void> = jest.fn()

  const renderRegisterForm = (): RenderResult => {
    const props: RegisterProps = {
      onSubmitClicked,
    }
    return render(<RegisterForm {...props} />)
  }

  it('should render cardNumber field', () => {
    const { getByTestId } = renderRegisterForm()
    expect(getByTestId('input-cardNumber')).toBeTruthy()
  })

  it('should render cvc field', () => {
    const { getByTestId } = renderRegisterForm()

    expect(getByTestId('input-cvc')).toBeTruthy()
  })

  it('should render expiry field', () => {
    const { getByTestId } = renderRegisterForm()

    expect(getByTestId('input-expiryDate')).toBeTruthy()
  })

 
})


