SELECT t.transfer_id, t.account_from AS senderAccountID, t.transfer_type_id, t.transfer_status_id, t.amount,
t.account_to AS toAccountId, 
(SELECT a.user_id, a.balance FROM account WHERE t.account_from = a.account_id),
(SELECT a.user_id, a.balance FROM account WHERE t.account_to= a.account_id)

FROM transfer t
JOIN transfer_type tt ON t.transfer_type_id = tt.transfer_type_id
JOIN transfer_status ts ON t.transfer_status_id = ts.transfer_status_id
JOIN account a ON a.account_id = t.account_from
WHERE t.transfer_id = 3001;

