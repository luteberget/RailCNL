module Rewrite where

import Data.Maybe

data Term
type Rewrite a = a -> Maybe a

downRules :: [Rewrite Term]
downRules = undefined

upRules :: [Rewrite Term]
upRules = undefined

smallStep :: [Rewrite Term] -> Rewrite Term
smallStep rules term = listToMaybe $ mapMaybe (\r -> r term) rules

normalForm :: Rewrite Term -> Term -> Term
normalForm rewriter term = fromMaybe term 
                            ((normalForm rewriter) <$> rewriter term)

