using day04;

namespace Day4
{
    public class BSTree
    {
        private BSTNode root;

        public void Insert(Employee emp)
        {
            root = Insert(root, emp);
        }

        private BSTNode Insert(BSTNode node, Employee emp)
        {
            if (node == null)
                return new BSTNode(emp);

            if (emp.Salary < node.Data.Salary)
                node.Left = Insert(node.Left, emp);
            else
                node.Right = Insert(node.Right, emp);

            return node;
        }

        public void InOrderTraversal()
        {
            InOrder(root);
        }

        private void InOrder(BSTNode node)
        {
            if (node == null)
                return;

            InOrder(node.Left);
            Console.WriteLine(node.Data);
            InOrder(node.Right);
        }

        public void Delete(double salary)
        {
            root = Delete(root, salary);
        }

        private BSTNode Delete(BSTNode node, double salary)
        {
            if (node == null)
                return null;

            if (salary < node.Data.Salary)
                node.Left = Delete(node.Left, salary);

            else if (salary > node.Data.Salary)
                node.Right = Delete(node.Right, salary);

            else
            {
                if (node.Left == null)
                    return node.Right;

                if (node.Right == null)
                    return node.Left;

                BSTNode minNode = FindMin(node.Right);

                node.Data = minNode.Data;

                node.Right = Delete(node.Right, minNode.Data.Salary);
            }

            return node;
        }

        private BSTNode FindMin(BSTNode node)
        {
            while (node.Left != null)
                node = node.Left;

            return node;
        }
    }
}