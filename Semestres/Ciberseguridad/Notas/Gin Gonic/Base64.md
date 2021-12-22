Decoding:
	import:
		"encoding/base64"
	code:
		decodedUser, err := base64.StdEncoding.DecodeString(user)
		fmt.PrintLn(string(decodeUser)) //convert to string before printing
			